import { useEffect, useState } from "react";

import type { Transaction } from "../types/Transaction";
import { getTransactions } from "../services/transactionService";


export default function TransactionPage() {

    const [transaction, setTransaction] = useState<Transaction[]>([]);

    useEffect(() => {

        getTransactions()
            .then(data => setTransaction(data))
            .catch(console.error);


    }, []);


    return (
        <div>

            <h1>Transactions</h1>
            {transaction.map(transaction => (
                <div key={transaction.id}>
                    <p key={transaction.personName}>Person: {transaction.personName}</p>
                    <p>Amount: {transaction.type === 0 ? "-" : ""}R${transaction.amount}</p>
                    <p>Description: {transaction.description}</p>
                </div>
            ))}

        </div>
    );
}