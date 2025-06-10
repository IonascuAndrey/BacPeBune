// InformaticaMindmap.tsx
import React from 'react';
import Mindmap from './Mindmap';
import type { Node, Edge } from 'react-flow-renderer';

function addUrls(nodes: Node[]): Node[] {
  return nodes.map(n => ({
    ...n,
    data: {
      ...n.data,
      url: `/Lectii/${n.id}`,
    }
  }));
}

const nodes: Node[] = addUrls([
  { id: '1', data: { label: 'Informatică' }, position: { x: 0, y: 0 } },
  { id: '2', data: { label: 'Clasa a IX-a' }, position: { x: 0, y: 100 } },

  // Elemente de bază ale limbajului C++
  { id: '3', data: { label: 'Elemente de bază ale limbajului C++' }, position: { x: -600-200-150, y: 200 } },
    { id: '4', data: { label: 'Introducere in C++', url: "/Lectii/4" }, position: { x: -600-200-150, y: 300 } },
    { id: '5', data: { label: 'Tipuri de date C++', url: "/Lectii/5" }, position: { x: -600-200-150, y: 400 } },
      { id: '6', data: { label: 'Tipul char', url: "/Lectii/6" }, position: { x: -750-200-150, y: 500 } },
      { id: '7', data: { label: 'Conversii de tip', url: "/Lectii/7" }, position: { x: -450-200-150, y: 500 } },
    { id: '8', data: { label: 'Variabile și constante', url: "/Lectii/8" }, position: { x: -600-200-150, y: 600 } },
    { id: '9', data: { label: 'Intrări/ieșiri în C++', url: "/Lectii/9" }, position: { x: -600-200-150, y: 700 } },
      { id: '10', data: { label: 'Citiri și scrieri cu format', url: "/Lectii/10" }, position: { x: -800-200-150, y: 800 } },
      { id: '11', data: { label: 'Secvențe escape', url: "/Lectii/11" }, position: { x: -600-200-150, y: 800 } },
      { id: '12', data: { label: 'Operații de I/O cu fișiere în C++', url: "/Lectii/12" }, position: { x: -400-200-150, y: 800 } },
    { id: '13', data: { label: 'Operatori C++', url: "/Lectii/13" }, position: { x: -600-200-150, y: 900 } },
      { id: '14', data: { label: 'Operații logice' }, position: { x: -800-200-150, y: 1000 } },
      { id: '15', data: { label: 'Operatorii de incrementare/decrementare', url: "/Lectii/14" }, position: { x: -600-200-150, y: 1000 } },
      { id: '16', data: { label: 'Operatorul condițional ?', url: "/Lectii/15" }, position: { x: -400-200-150, y: 1000 } },
    { id: '17', data: { label: 'Funcții C++ predefinite', url: "/Lectii/16" }, position: { x: -600-200-150, y: 1100 } },
    { id: '18', data: { label: 'Codul ASCII', url: "/Lectii/17" }, position: { x: -600-200-150, y: 1200 } },

  // Structuri de control
  { id: '19', data: { label: 'Structuri de control' }, position: { x: -300-150, y: 200 } },
    { id: '20', data: { label: 'Structura liniară' }, position: { x: -500-150, y: 300 } },
    { id: '21', data: { label: 'Structuri alternative' }, position: { x: -300-150, y: 300 } },
    { id: '22', data: { label: 'Structuri repetitive' }, position: { x: -100-150, y: 300 } },

  // Algoritmi elementari
  { id: '23', data: { label: 'Algoritmi elementari' }, position: { x: 0, y: 200 } },
    { id: '24', data: { label: 'Maxime și minime' }, position: { x: 0, y: 300 } },
    { id: '25', data: { label: 'Cifrele unui număr' }, position: { x: 0, y: 400 } },
      { id: '26', data: { label: 'Cifra de control a unui număr' }, position: { x: 0, y: 500 } },
    { id: '27', data: { label: 'Divizibilitate' }, position: { x: 0, y: 600 } },
      { id: '28', data: { label: 'Divizorii unui număr' }, position: { x: -400, y: 700 } },
      { id: '29', data: { label: 'Algoritmul lui Euclid' }, position: { x: -200, y: 700 } },
      { id: '30', data: { label: 'Verificare primalității' }, position: { x: 0, y: 700 } },
      { id: '31', data: { label: 'Descompunerea în factori primi' }, position: { x: 200, y: 700 } },
      { id: '32', data: { label: 'Aplicații ale descompunerii în factori primi' }, position: { x: 400, y: 700 } },
    { id: '33', data: { label: 'Șirul lui Fibonacci' }, position: { x: 0, y: 800 } },
    { id: '34', data: { label: 'Baze de numerație' }, position: { x: 0, y: 900 } },
      { id: '35', data: { label: 'Înmulțirea a la russe și ridicarea la putere rapidă' }, position: { x: 0, y: 1000 } },

  // Tablouri unidimensionale
  { id: '36', data: { label: 'Tablouri unidimensionale' }, position: { x: 300+350, y: 200 } },
    { id: '37', data: { label: 'Introducere' }, position: { x: 300+350, y: 300 } },
    { id: '38', data: { label: 'Inserări și ștergeri' }, position: { x: 300+350, y: 400 } },
    { id: '39', data: { label: 'Verificarea unor proprietăți' }, position: { x: 300+350, y: 500 } },
    { id: '40', data: { label: 'Sortarea vectorilor' }, position: { x: 300+350, y: 600 } },
    { id: '41', data: { label: 'Interclasare' }, position: { x: 300+350, y: 700 } },
    { id: '42', data: { label: 'Secvențe în vectori' }, position: { x: 300+350, y: 800 } },
      { id: '43', data: { label: 'Sume parțiale' }, position: { x: 100+350, y: 900 } },
      { id: '44', data: { label: 'Secvență de sumă maximă' }, position: { x: 300+350, y: 900 } },
      { id: '45', data: { label: 'Șmenul lui Mars - Difference Arrays' }, position: { x: 500+350, y: 900 } },
    { id: '46', data: { label: 'Căutarea binară' }, position: { x: 300+350, y: 1000 } },
    { id: '47', data: { label: 'Vectori caracteristici și de frecvență' }, position: { x: 300+350, y: 1100 } },
      { id: '48', data: { label: 'Ciurul lui Eratostene' }, position: { x: 150+350, y: 1200 } },
      { id: '49', data: { label: 'Algoritmi de tipul Ciurul lui Eratostene' }, position: { x: 450+350, y: 1200 } },
    { id: '50', data: { label: 'Aritmetica numerelor mari' }, position: { x: 300+350, y: 1300 } },
    { id: '51', data: { label: 'Divizibilitate' }, position: { x: 300+350, y: 1400 } },

  // Tablouri bidimensionale
  { id: '52', data: { label: 'Tablouri bidimensionale' }, position: { x: 600+500, y: 200 } },
    { id: '53', data: { label: 'Tablouri bidimensionale' }, position: { x: 600+500, y: 300 } },
      { id: '54', data: { label: 'Declararea matricelor' }, position: { x: 450+500, y: 400 } },
      { id: '55', data: { label: 'Parcurgerea matricelor' }, position: { x: 750+500, y: 400 } },
    { id: '56', data: { label: 'Tablouri pătratice' }, position: { x: 600+500, y: 500 } },
    { id: '57', data: { label: 'Sume parțiale în matrice' }, position: { x: 600+500, y: 600 } },
]);

const edges: Edge[] = [
  { id: 'e1-2', source: '1', target: '2' },

  // Legături Clasa a IX-a -> capitole
  { id: 'e2-3', source: '2', target: '3' },
  { id: 'e2-19', source: '2', target: '19' },
  { id: 'e2-23', source: '2', target: '23' },
  { id: 'e2-36', source: '2', target: '36' },
  { id: 'e2-52', source: '2', target: '52' },

  // Elemente de bază ale limbajului C++
  { id: 'e3-4', source: '3', target: '4' },
    { id: 'e4-5', source: '4', target: '5' },
      { id: 'e5-6', source: '5', target: '6' },
      { id: 'e5-7', source: '5', target: '7' },
    { id: 'e6-8', source: '6', target: '8' },
    { id: 'e7-8', source: '7', target: '8' },
    { id: 'e8-9', source: '8', target: '9' },
      { id: 'e9-10', source: '9', target: '10' },
      { id: 'e9-11', source: '9', target: '11' },
      { id: 'e9-12', source: '9', target: '12' },
    { id: 'e10-13', source: '10', target: '13' },
    { id: 'e11-13', source: '11', target: '13' },
    { id: 'e12-13', source: '12', target: '13' },
      { id: 'e13-14', source: '13', target: '14' },
      { id: 'e13-15', source: '13', target: '15' },
      { id: 'e13-16', source: '13', target: '16' },
    { id: 'e14-17', source: '14', target: '17' },
    { id: 'e15-17', source: '15', target: '17' },
    { id: 'e16-17', source: '16', target: '17' },
    { id: 'e174-18', source: '17', target: '18' },

  // Structuri de control
  { id: 'e19-20', source: '19', target: '20' },
  { id: 'e19-21', source: '19', target: '21' },
  { id: 'e19-22', source: '19', target: '22' },

  // Algoritmi elementari
  { id: 'e23-24', source: '23', target: '24' },
  { id: 'e24-25', source: '24', target: '25' },
    { id: 'e25-26', source: '25', target: '26' },
  { id: 'e26-27', source: '26', target: '27' },
    { id: 'e27-28', source: '27', target: '28' },
    { id: 'e27-29', source: '27', target: '29' },
    { id: 'e27-30', source: '27', target: '30' },
    { id: 'e27-31', source: '27', target: '31' },
    { id: 'e27-32', source: '27', target: '32' },
  { id: 'e28-33', source: '28', target: '33' },
  { id: 'e29-33', source: '29', target: '33' },
  { id: 'e30-33', source: '30', target: '33' },
  { id: 'e31-33', source: '31', target: '33' },
  { id: 'e32-33', source: '32', target: '33' },
  { id: 'e33-34', source: '33', target: '34' },
    { id: 'e34-35', source: '34', target: '35' },

  // Tablouri unidimensionale
  { id: 'e36-37', source: '36', target: '37' },
  { id: 'e37-38', source: '37', target: '38' },
  { id: 'e38-39', source: '38', target: '39' },
  { id: 'e39-40', source: '39', target: '40' },
  { id: 'e40-41', source: '40', target: '41' },
  { id: 'e41-42', source: '41', target: '42' },
    { id: 'e42-43', source: '42', target: '43' },
    { id: 'e42-44', source: '42', target: '44' },
    { id: 'e42-45', source: '42', target: '45' },
  { id: 'e43-46', source: '43', target: '46' },
  { id: 'e44-46', source: '44', target: '46' },
  { id: 'e45-46', source: '45', target: '46' },
  { id: 'e46-47', source: '46', target: '47' },
    { id: 'e47-48', source: '47', target: '48' },
    { id: 'e47-49', source: '47', target: '49' },
  { id: 'e48-50', source: '48', target: '50' },
  { id: 'e49-50', source: '49', target: '50' },
  { id: 'e50-51', source: '50', target: '51' },

  // Tablouri bidimensionale
  { id: 'e52-53', source: '52', target: '53' },
    { id: 'e53-54', source: '53', target: '54' },
    { id: 'e53-55', source: '53', target: '55' },
  { id: 'e54-56', source: '54', target: '56' },
  { id: 'e55-56', source: '55', target: '56' },
  { id: 'e56-57', source: '56', target: '57' },
];

export default function InformaticaMindmap() {
  return <Mindmap userNodes={nodes} userEdges={edges} />;
}
