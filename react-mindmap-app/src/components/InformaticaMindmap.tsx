// InformaticaMindmap.tsx
import React from 'react';
import Mindmap from './Mindmap';
import type { Node, Edge } from 'react-flow-renderer';

const nodes: Node[] = [
  { id: '4', data: { label: 'Informatică'}, position: { x: 0, y: 400 } },
  { id: '5', data: { label: 'Clasa a IX-a'}, position: { x: 0, y: 500 } },
  { id: '6', data: { label: 'Elemente de bază ale limbajului C++'}, position: { x: -400, y: 600 } },
  { id: '7', data: { label: 'Structuri de control'}, position: { x: -200, y: 600 } },
  { id: '8', data: { label: 'Algoritmi elementari'}, position: { x: 0, y: 600 } },
  { id: '9', data: { label: 'Tablouri unidimensionale'}, position: { x: 200, y: 600 } },
  { id: '10', data: { label: 'Tablouri bidimensionale'}, position: { x: 400, y: 600 } },
  { id: '11', data: { label: 'Introducere in C++'}, position: { x: -400, y: 700 } },
  { id: '12', data: { label: 'Tipul char'}, position: { x: -400, y: 800 } },
  { id: '13', data: { label: 'Conversii de tip'}, position: { x: -400, y: 900 } },
  { id: '14', data: { label: 'Variabile și constante'}, position: { x: -400, y: 1000 } },
  { id: '15', data: { label: 'Intrări/ieșiri în C++'}, position: { x: -400, y: 1100 } },
  { id: '16', data: { label: 'Citiri și scrieri cu format'}, position: { x: -400, y: 1200 } },
  { id: '17', data: { label: 'Secvențe escape'}, position: { x: -400, y: 1300 } },
  { id: '18', data: { label: 'Operații de I/O cu fișiere în C++'}, position: { x: -400, y: 1400 } },
  { id: '19', data: { label: 'Operatori C++'}, position: { x: -400, y: 1500 } },
  { id: '20', data: { label: 'Operații logice'}, position: { x: -400, y: 1600 } },
  { id: '21', data: { label: 'Operatorii de incrementare/decrementare'}, position: { x: -400, y: 1700 } },
  { id: '22', data: { label: 'Operatorul condițional ?'}, position: { x: -400, y: 1800} },
  { id: '23', data: { label: 'Funcții C++ predefinite'}, position: { x: -400, y: 1900 } },
  { id: '24', data: { label: 'Codul ASCII'}, position: { x: -400, y: 2000 } },
];

const edges: Edge[] = [
  { id: 'e4-5', source: '4', target: '5', animated: true },
  { id: 'e5-6', source: '5', target: '6', animated: true },
  { id: 'e5-7', source: '5', target: '7', animated: true },
  { id: 'e5-8', source: '5', target: '8', animated: true },
  { id: 'e5-9', source: '5', target: '9', animated: true },
  { id: 'e5-10', source: '5', target: '10', animated: true },
  { id: 'e6-11', source: '6', target: '11', animated: true },
  { id: 'e11-12', source: '11', target: '12', animated: true },
  { id: 'e12-13', source: '12', target: '13', animated: true },
  { id: 'e13-14', source: '13', target: '14', animated: true },
  { id: 'e14-15', source: '14', target: '15', animated: true },
  { id: 'e15-16', source: '15', target: '16', animated: true },
  { id: 'e16-17', source: '16', target: '17', animated: true },
  { id: 'e17-18', source: '17', target: '18', animated: true },
  { id: 'e18-19', source: '18', target: '19', animated: true },
  { id: 'e19-20', source: '19', target: '20', animated: true },
  { id: 'e20-21', source: '20', target: '21', animated: true },
  { id: 'e21-22', source: '21', target: '22', animated: true },
  { id: 'e22-23', source: '22', target: '23', animated: true },
  { id: 'e23-24', source: '23', target: '24', animated: true },
];

export default function InformaticaMindmap() {
  return <Mindmap userNodes={nodes} userEdges={edges} />;
}
