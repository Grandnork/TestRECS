import { useEffect, useState } from "react";

import type { GeneralReport } from "../types/GeneralReport";
import type { HouseholdTotal } from "../types/HouseholdTotal";
import { getGeneralReport } from "../services/reportService";
import { getHouseholdTotal } from "../services/reportService";


export default function ReportsPage() {

    const [general, setGeneral] = useState<GeneralReport | null>(null);
    const [household, setHousehold] = useState<HouseholdTotal | null>(null);

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        async function loadReports(){
            try{
                const generalData = await getGeneralReport();
                const householdData = await getHouseholdTotal();
                console.log(generalData);
                console.log(householdData);
                setGeneral(generalData);
                setHousehold(householdData);
            } catch (err) {
                console.error(err)
                setError("Failed to load reports.");
            } finally {
                setLoading(false);
            }
            
        }
        loadReports();
    }, []);
    if (loading){
        return <p>Loading...</p>
    }
    if (error) {
        return <p>{error}</p>
    }
    /*
        Teste de CSS para melhoria de interface final.
        TODO: aplicar as informações em cards como componentes para facilitar 
        modicações de CSS e utilização.
    */
    return (
        <div>

            <h1>General Reports</h1>

            <p>Total Income(R$): {general?.totalIncome}</p>
            <p>Total Expenses(R$): {general?.totalExpenses}</p>
            <p>Balance(R$): {general?.balance}</p>

            <h3>Residents</h3>
            <div style={{
                    display: "flex",
                    gap: "20px",
                    flexWrap: "wrap",
                    justifyContent: "center",
                    padding: "1rem"
                }}>
            {general?.people.map(person => (
                <div key={person.personId}>
                    <p>{person.personName}</p>
                    <p>Income(R$): {person.totalIncome}</p>
                    <p>Expenses(R$): {person.totalExpenses}</p>
                    <p>Balance(R$): {person.balance}</p>
                    
                </div>
            ))}
            </div>
            
            {/*
                A ideia de dois controladores diferentes para um "relatório" parte da simplificação 
                necessária quando são trabalhados períodos grandes, enquanto são necessários detalhes em períodos curtos.

                O controlador geral, por exemplo, seria responsável por medir gastos semanais e mensais de forma detalhada. 
                Enquanto o controlador da residência mediria informações simplificadas 
                entre períodos trimestrais, semestrais ou anuais.

                TODO: Adicionar uma chave de tempo durante o cadastro de despesas para implementação.
            */}

            <h1>Household Reports</h1>

            {household && 
                <div>
                    <p>Total Income(R$): {household.totalIncome}</p>
                    <p>Total Expenses(R$): {household.totalExpenses}</p>
                    <p>Total Household Balance(R$): {household.balance}</p>
                </div>
            }

        </div>
    );
}