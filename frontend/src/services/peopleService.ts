import api from "../services/api";
import type { Person } from "../types/Person";


export async function getPeople() {
    const response = await api.get<Person[]>("/people");

    return response.data;
}