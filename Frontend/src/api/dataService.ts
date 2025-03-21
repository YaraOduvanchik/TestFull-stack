import api from "./api";

export type TestData = {
	id?: string;
	code: number;
	value: string;
};

export const getData = async (
	code?: number,
	value?: string
): Promise<TestData[]> => {
	try {
		const params: { Code?: number; Value?: string } = {};
		if (code) params.Code = code;
		if (value) params.Value = value;

		const response = await api.get("/Data", { params });
		return response.data.testsData as TestData[];
	} catch (error) {
		console.error("Ошибка GET /Data:");
		throw error;
	}
};

export const saveData = async (data: Omit<TestData, "id">[]): Promise<void> => {
	try {
		await api.post("/Data", { testsData: data });
	} catch (error) {
		console.error("Ошибка POST /Data:");
		throw error;
	}
};
