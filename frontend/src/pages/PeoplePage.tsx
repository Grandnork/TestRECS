import { useEffect, useState } from "react";

import type { Person } from "../types/Person";
import { getPeople } from "../services/peopleService";


export default function PeoplePage() {

    const [people, setPeople] = useState<Person[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        async function loadPeople(){
            try{
                const data = await getPeople();
                setPeople(data);
            } catch (err) {
                console.error(err)
                setError("Failed to load people.");
            } finally {
                setLoading(false);
            }
            
        }
        loadPeople();
    }, []);
    if (loading){
        return <p>Loading...</p>
    }
    if (error) {
        return <p>{error}</p>
    }
    /*
        In-line css para ajudar a decidir a aparência final e iniciar a inclusão de botões.
    */
    return (
        <div style={{ padding: "2rem", margin: "0 auto" }}>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Age</th>
                        <th>Type</th>
                        <th>Actions</th>
                    </tr>
                </thead>

                <tbody>
                    {people.map(person => (
                        <tr key={person.id}>
                            <td>{person.name}</td>
                            <td>{person.age}</td>
                            <td>{person.age < 18 ? "Minor" : "Adult"}</td>
                            <td>
                                <button>View Report</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}