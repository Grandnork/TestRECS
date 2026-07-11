import api from "../services/api";
import type { Transaction } from "../types/Transaction";


export async function getTransactions() {
    const response = await api.get<Transaction[]>("/transactions");
    console.log(response.data);
    return response.data;
}