import { TestData } from "../api/dataService";
import Loader from "./Loader";

type DataTableProps = {
	data: TestData[];
	loading?: boolean;
};

const DataTable = ({ data, loading }: DataTableProps) => {
	return (
		<div className="rounded-xl border border-gray-200 shadow-sm bg-white overflow-hidden">
			<table className="w-full">
				<thead className="bg-gray-100">
					<tr>
						<th className="px-6 py-4 text-left text-sm font-semibold text-gray-800 uppercase tracking-wider">
							Код
						</th>
						<th className="px-6 py-4 text-left text-sm font-semibold text-gray-800 uppercase tracking-wider">
							Значение
						</th>
					</tr>
				</thead>
				<tbody className="divide-y divide-gray-100">
					{data.length === 0 && !loading && (
						<tr>
							<td
								colSpan={2}
								className="px-6 py-8 text-center text-gray-500 text-lg"
							>
								Нет данных для отображения
							</td>
						</tr>
					)}
					{loading && (
						<tr>
							<td colSpan={2}>
								<Loader />
							</td>
						</tr>
					)}
					{data.map((item) => (
						<tr
							key={item.id}
							className="hover:bg-indigo-50 transition-colors duration-200"
						>
							<td className="px-6 py-4 text-gray-700 font-medium">
								{item.code}
							</td>
							<td className="px-6 py-4 text-gray-700">{item.value}</td>
						</tr>
					))}
				</tbody>
			</table>
		</div>
	);
};

export default DataTable;
