import api from "../services/api";
import type { GeneralReport } from "../types/GeneralReport";
import type { HouseholdTotal } from "../types/HouseholdTotal";
import type { PersonReport } from "../types/PersonReport";

export async function getGeneralReport(): Promise<GeneralReport> {

    const response = await api.get<GeneralReport>("/reports/general");

    return response.data;
}

export async function getHouseholdTotal(): Promise<HouseholdTotal> {

    const response = await api.get<HouseholdTotal>("/reports/household-total");

    return response.data;
}


export async function getPersonReport(id: string): Promise<PersonReport> {

    const response = await api.get<PersonReport>(`/reports/person/${id}`);

    return response.data;
}
