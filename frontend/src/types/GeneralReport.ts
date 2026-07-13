export interface PersonSummary {
    personId: string;
    personName: string;
    totalIncome: number;
    totalExpenses: number;
    balance: number;
}

export interface GeneralReport {
    totalIncome: number;
    totalExpenses: number;
    balance: number;
    people: PersonSummary[];
}