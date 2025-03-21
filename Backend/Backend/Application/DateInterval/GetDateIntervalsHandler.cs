using System.Data;
using Backend.Contracts.Dtos;
using Backend.Contracts.Responses;
using Dapper;

namespace Backend.Application.DateInterval;

public class GetDateIntervalsHandler
{
    private readonly IDbConnection _dbConnection;

    public GetDateIntervalsHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<GetDateIntervalsResponse> Handle(CancellationToken cancellationToken)
    {
        const string sql = @"
                WITH Intervals AS (
                    SELECT
                        d.id,
                        d.Dt AS start_date,
                        LEAD(d.Dt) OVER (PARTITION BY d.Id ORDER BY d.Dt) AS end_date
                    FROM Dates d
                )
                SELECT
                    i.id AS Id,
                    i.start_date AS StartDate,
                    i.end_date AS EndDate
                FROM Intervals i
                WHERE i.end_date IS NOT NULL;";

        var intervals = await _dbConnection.QueryAsync<DateIntervalDto>(sql);

        return new GetDateIntervalsResponse(intervals.ToList());
    }
}