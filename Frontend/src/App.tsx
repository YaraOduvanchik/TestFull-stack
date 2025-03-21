import { useEffect, useState } from "react";
import { getData, saveData, TestData } from "./api/dataService";
import DataForm from "./components/DataForm";
import DataTable from "./components/DataTable";
import ErrorAlert from "./components/ErrorAlert";
import LocalDataList from "./components/LocalDataList";

function App() {
	const [data, setData] = useState<TestData[]>([]);
	const [localData, setLocalData] = useState<Omit<TestData, "id">[]>([]);
	const [isLoading, setIsLoading] = useState(true);
	const [error, setError] = useState<string | null>(null);

	const loadData = async () => {
		setError(null);
		setIsLoading(true);
		try {
			const result = await getData();
			setData(result);
		} catch {
			setError("Ошибка при загрузке данных с сервера");
		} finally {
			setIsLoading(false);
		}
	};

	const handleSave = async () => {
		try {
			setIsLoading(true);
			setError(null);
			await saveData(localData);
			setLocalData([]);
			await loadData();
		} catch {
			setError("Ошибка при сохранении данных");
		} finally {
			setIsLoading(false);
		}
	};

	useEffect(() => {
		loadData();
	}, []);

	return (
		<div className="min-h-screen bg-gradient-to-br from-gray-50 to-gray-100 py-12">
			<div className="max-w-5xl mx-auto px-6">
				<header className="mb-10">
					<h1 className="text-4xl font-extrabold text-gray-900 tracking-tight">
						Управление данными
					</h1>
					<p className="text-gray-600 mt-3 text-lg">
						Добавляйте новые записи и синхронизируйте с сервером
					</p>
				</header>

				<DataForm
					onAdd={(newData) => setLocalData((prev) => [...prev, newData])}
					onSave={handleSave}
					saveDisabled={localData.length === 0 || isLoading}
				/>

				<LocalDataList data={localData} onClear={() => setLocalData([])} />

				<section className="mt-10">
					<div className="flex justify-between items-center mb-6">
						<h2 className="text-2xl font-semibold text-gray-800">
							Данные с сервера
						</h2>
						<div className="flex gap-3">
							<button
								onClick={loadData}
								disabled={isLoading}
								className="text-sm text-indigo-600 hover:text-indigo-800 font-medium transition-colors disabled:opacity-50 disabled:cursor-not-allowed"
							>
								Обновить
							</button>
						</div>
					</div>

					{error && (
						<ErrorAlert
							message={error}
							onRetry={error.includes("сохранении") ? handleSave : loadData}
						/>
					)}

					<DataTable data={data} loading={isLoading} />
				</section>
			</div>
		</div>
	);
}

export default App;
