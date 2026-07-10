import { BrowserRouter, Routes, Route, Navigate, Link } from "react-router-dom";

import PeoplePage from "./pages/PeoplePage";
import TransactionsPage from "./pages/TransactionsPage";
import ReportsPage from "./pages/ReportsPage";

export default function App() {
    return (
        <BrowserRouter>
            <nav>
                <Link to="/">People</Link> |{" "}
                <Link to="/api/transactions">Transactions</Link> |{" "}
                <Link to="/api/reports">Reports</Link>
            </nav>

            

            <Routes>
                {/* Redirect "/" to "/people" aplicação de replace para o usuario não entrar em loop ao usar Back no browser */}
                <Route path="/" element={<Navigate to="/api/people" replace />} />
                <Route path="/api/people" element={<PeoplePage />} />
                <Route path="/api/transactions" element={<TransactionsPage />} />
                <Route path="/api/reports" element={<ReportsPage />} />
            </Routes>
        </BrowserRouter>
    );
}