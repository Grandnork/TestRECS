import { BrowserRouter, Routes, Route, Link } from "react-router-dom";

import PeoplePage from "./pages/PeoplePage";
import TransactionsPage from "./pages/TransactionsPage";
import ReportsPage from "./pages/ReportsPage";

export default function App() {
    return (
        <BrowserRouter>
            <nav>
                <Link to="/">People</Link> |{" "}
                <Link to="/transactions">Transactions</Link> |{" "}
                <Link to="/reports">Reports</Link>
            </nav>

            

            <Routes>
                <Route path="/" element={<PeoplePage />} />
                <Route path="/transactions" element={<TransactionsPage />} />
                <Route path="/reports" element={<ReportsPage />} />
            </Routes>
        </BrowserRouter>
    );
}