import { useEffect, useState } from "react";

import type { Person } from "../types/Person";
import { getPeople } from "../services/peopleService";


export default function PeoplePage() {

    const [people, setPeople] = useState<Person[]>([]);

    useEffect(() => {

        getPeople()
            .then(data => setPeople(data))
            .catch(console.error);


    }, []);


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