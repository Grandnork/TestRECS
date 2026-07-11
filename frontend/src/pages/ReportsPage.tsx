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

    return (
        <div>

            <h1>General Reports</h1>

            {general &&
                <div key={general.personId}>
                    <p>{general.personName}</p>
                    <p>{general.totalIncome}</p>
                    <p>{general.totalExpenses}</p>
                    <p>{general.balance}</p>
                </div>
            }

            <h1>Household Reports</h1>

            {household && 
                <div key={household.personId}>
                    <p>{household.personName}</p>
                    <p>{household.totalIncome}</p>
                    <p>{household.totalExpenses}</p>
                    <p>{household.balance}</p>
                </div>
            }

        </div>
    );
}