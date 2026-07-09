export interface Transaction {
    id: string;
    description: string;
    amount: number;
    type: number;
    personId: string;
    personName: string;
}