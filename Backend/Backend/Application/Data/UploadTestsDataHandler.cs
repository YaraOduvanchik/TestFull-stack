using Backend.Contracts.Requests;
using Backend.Domain;
using Backend.Infrastructure;

namespace Backend.Application.Data;

public class UploadTestsDataHandler
{
    private readonly AppDbContext _context;

    public UploadTestsDataHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UploadTestsDataRequest uploadTestsDataRequest, CancellationToken cancellationToken)
    {
        if (uploadTestsDataRequest.TestsData == null || uploadTestsDataRequest.TestsData.Count == 0)
        {
            return "Данные отсутствуют";
        }

        _context.DataItems.RemoveRange(_context.DataItems);
        await _context.SaveChangesAsync(cancellationToken);

        // Преобразование и сортировка
        var dataList = uploadTestsDataRequest.TestsData
            .Select(kv => new DataItem
            {
                Code = kv.Code,
                Value = kv.Value
            })
            .OrderBy(d => d.Code)
            .ToList();

        // Сохранение в БД
        await _context.DataItems.AddRangeAsync(dataList, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return string.Empty;
    }
}