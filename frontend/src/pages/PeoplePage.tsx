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

    return (
        <div>

            <h1>Pessoas</h1>

            {people.map(person => (
                <div key={person.id}>
                    <p>{person.name} - {person.age} </p>
                </div>
            ))}

        </div>
    );
}