import { TestData } from "../api/dataService";

type LocalDataListProps = {
	data: Omit<TestData, "id">[];
	onClear?: () => void;
};

const LocalDataList = ({ data, onClear }: LocalDataListProps) => {
	if (data.length === 0) return null;

	return (
		<div className="mt-8 p-6 bg-indigo-50 rounded-2xl border border-indigo-100 shadow-sm">
			<div className="flex justify-between items-center mb-4">
				<h2 className="text-xl font-semibold text-indigo-900">
					Новые записи ({data.length})
				</h2>
				{onClear && (
					<button
						onClick={onClear}
						className="text-sm text-indigo-600 hover:text-indigo-800 font-medium transition-colors"
					>
						Очистить
					</button>
				)}
			</div>
			<div className="space-y-3">
				{data.map((item, index) => (
					<div
						key={index}
						className="flex justify-between items-center p-4 bg-white rounded-lg shadow-sm border border-indigo-50 hover:shadow-md transition-shadow"
					>
						<span className="text-gray-700">
							<span className="font-medium text-indigo-700">Код:</span>{" "}
							{item.code},
							<span className="font-medium ml-2 text-indigo-700">
								Значение:
							</span>{" "}
							{item.value}
						</span>
					</div>
				))}
			</div>
		</div>
	);
};

export default LocalDataList;
