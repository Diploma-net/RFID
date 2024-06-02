import React from 'react';
import { jsPDF } from 'jspdf';

export default function Reportpage() {
  const generatePdf = () => {
    const doc = new jsPDF();
    doc.text("Hello, World!", 10, 10);
    doc.save("example.pdf");
  };

  return (
    <div>
      <button onClick={generatePdf}>Generate PDF</button>
    </div>
  );
}
