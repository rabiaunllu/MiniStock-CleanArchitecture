import StockManagement from './pages/StockManagement/StockManagement';

function App() {
  return (
    <div>
      <header style={{ padding: '20px', backgroundColor: '#282c34', color: 'white' }}>
        <h1>MiniStock Admin Panel</h1>
      </header>
      <main>
        <StockManagement />
      </main>
    </div>
  );
}

export default App;