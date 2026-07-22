import React, { useState } from 'react';

const StockManagement = () => {
  // Videolarda öğrendiğimiz useState! Tabloda gösterilecek sahte verilerimiz (Mock Data):
  const [stocks, setStocks] = useState([
    { id: 1, name: 'Hammadde A', code: 'STK-001', quantity: 150, unit: 'Kg' },
    { id: 2, name: 'Ambalaj Kutusu', code: 'STK-002', quantity: 400, unit: 'Adet' },
    { id: 3, name: 'Sanayi Yağı', code: 'STK-003', quantity: 80, unit: 'Litre' }
  ]);

  return (
    <div style={{ padding: '20px', fontFamily: 'Arial, sans-serif' }}>
      <h2>Stok Yönetim Modülü</h2>
      <p>Depodaki anlık stok durumları ve malzeme listesi aşağıdadır:</p>

      {/* Tablo Yapısı */}
      <table border="1" cellPadding="10" style={{ width: '100%', borderCollapse: 'collapse', marginTop: '20px' }}>
        <thead>
          <tr style={{ backgroundColor: '#f2f2f2', textAlign: 'left' }}>
            <th>ID</th>
            <th>Ürün Kodu</th>
            <th>Ürün Adı</th>
            <th>Miktar</th>
            <th>Birim</th>
          </tr>
        </thead>
        <tbody>
          {/* Videolarda öğrendiğimiz map() fonksiyonu ile diziyi ekrana basıyoruz */}
          {stocks.map((item) => (
            <tr key={item.id}>
              <td>{item.id}</td>
              <td>{item.code}</td>
              <td>{item.name}</td>
              <td>{item.quantity}</td>
              <td>{item.unit}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default StockManagement;