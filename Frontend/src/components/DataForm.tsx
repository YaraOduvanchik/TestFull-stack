import { useState } from "react";

interface DataFormProps {
	onAdd: (newData: { code: number; value: string }) => void;
	onSave: () => void;
	saveDisabled: boolean;
}

const DataForm = ({ onAdd, onSave, saveDisabled }: DataFormProps) => {
	const [code, setCode] = useState("");
	const [value, setValue] = useState("");

	const handleAdd = () => {
		if (!code || !value) return;
		onAdd({ code: Number(code), value });
		setCode("");
		setValue("");
	};

	return (
		<div className="bg-white p-6 rounded-2xl shadow-sm border border-gray-100">
			<div className="grid grid-cols-3 gap-6">
				<div>
					<label className="block text-sm font-semibold text-gray-800 mb-2">
						Код
					</label>
					<input
						type="number"
						className="w-full px-4 py-3 border border-gray-200 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 transition-all bg-gray-50"
						value={code}
						onChange={(e) => setCode(e.target.value)}
					/>
				</div>
				<div>
					<label className="block text-sm font-semibold text-gray-800 mb-2">
						Значение
					</label>
					<input
						type="text"
						className="w-full px-4 py-3 border border-gray-200 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 transition-all bg-gray-50"
						value={value}
						onChange={(e) => setValue(e.target.value)}
					/>
				</div>
				<div className="self-end">
					<button
						className="w-full bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-3 rounded-lg transition-colors font-semibold disabled:bg-gray-400 disabled:cursor-not-allowed"
						onClick={handleAdd}
						disabled={!code || !value}
					>
						Добавить
					</button>
				</div>
			</div>
			<button
				className="mt-6 w-full bg-emerald-600 hover:bg-emerald-700 text-white px-4 py-3 rounded-lg font-semibold transition-colors disabled:bg-gray-400 disabled:cursor-not-allowed shadow-md"
				onClick={onSave}
				disabled={saveDisabled}
			>
				Сохранить на сервер
			</button>
		</div>
	);
};

export default DataForm;
