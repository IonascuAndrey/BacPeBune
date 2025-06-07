// MatematicaMindmap.tsx
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

var leftGeom = -100;
var leftAritm = -100 +leftGeom;

const nodes: Node[] = addUrls([
  { id: '60', data: { label: 'Matematică' }, position: { x: 0, y: 0 } },
  { id: '61', data: { label: 'Clasa a IX-a' }, position: { x: 0, y: 100 } },

  // Aritmetică și Algebra
  { id: '62', data: { label: 'Aritmetică și Algebra' }, position: { x: -450+leftAritm, y: 200 } },
    { id: '63', data: { label: 'Mulțimi. Operații cu mulțimi' }, position: { x: -450+leftAritm, y: 300 } },
    { id: '64', data: { label: 'Numere reale' }, position: { x: -450+leftAritm, y: 400 } },
      { id: '65', data: { label: 'Fracții zecimale, raționale, iraționale' }, position: { x: -650+leftAritm, y: 500 } },
      { id: '66', data: { label: 'Radicali. Proprietăți' }, position: { x: -450+leftAritm, y: 500 } },
      { id: '67', data: { label: 'Puteri cu exponent real' }, position: { x: -250+leftAritm, y: 500 } },
    { id: '68', data: { label: 'Polinoame' }, position: { x: -450+leftAritm, y: 600 } },
      { id: '69', data: { label: 'Operații cu polinoame' }, position: { x: -600+leftAritm, y: 700 } },
      { id: '70', data: { label: 'Divizibilitate la polinoame. Teorema restului' }, position: { x: -300+leftAritm, y: 700 } },
    { id: '71', data: { label: 'Ecuații și inecuații de gradul I' }, position: { x: -450+leftAritm, y: 800 } },
    { id: '72', data: { label: 'Ecuații și inecuații de gradul II' }, position: { x: -450+leftAritm, y: 900 } },
      { id: '73', data: { label: 'Formule de rezolvare, delta' }, position: { x: -600+leftAritm, y: 1000 } },
      { id: '74', data: { label: 'Sisteme de ecuații' }, position: { x: -300+leftAritm, y: 1000 } },
    { id: '75', data: { label: 'Funcții' }, position: { x: -450+leftAritm, y: 1100 } },
      { id: '76', data: { label: 'Funcția de gradul I' }, position: { x: -650+leftAritm, y: 1200 } },
      { id: '77', data: { label: 'Funcția de gradul II' }, position: { x: -450+leftAritm, y: 1200 } },
      { id: '78', data: { label: 'Funcții definite pe intervale' }, position: { x: -250+leftAritm, y: 1200 } },
    { id: '79', data: { label: 'Progresii aritmetice și geometrice' }, position: { x: -450+leftAritm, y: 1300 } },

  // Geometrie
  { id: '80', data: { label: 'Geometrie' }, position: { x: -150+leftGeom, y: 200 } },
    { id: '81', data: { label: 'Geometrie plană. Elemente de bază' }, position: { x: -150+leftGeom, y: 300 } },
      { id: '82', data: { label: 'Axe, unghiuri, bisectoare, mediatoare' }, position: { x: -350+leftGeom, y: 400 } },
      { id: '83', data: { label: 'Triunghiuri. Clasificare, proprietăți' }, position: { x: -150+leftGeom, y: 400 } },
      { id: '84', data: { label: 'Cercuri. Arce, coarde, secante, tangente' }, position: { x: 50+leftGeom, y: 400 } },
    { id: '85', data: { label: 'Geometrie analitică' }, position: { x: -150+leftGeom, y: 500 } },
      { id: '86', data: { label: 'Coordonate carteziene în plan' }, position: { x: -350+leftGeom, y: 600 } },
      { id: '87', data: { label: 'Ecuația dreptei' }, position: { x: -150+leftGeom, y: 600 } },
      { id: '88', data: { label: 'Distanțe în plan (punct-punct, punct-dreaptă, dreaptă-dreaptă)' }, position: { x: 50+leftGeom, y: 600 } },
    { id: '89', data: { label: 'Teorema lui Pitagora, teoreme metrice' }, position: { x: -150+leftGeom, y: 700 } },
    { id: '90', data: { label: 'Arie și perimetru pentru figuri plane' }, position: { x: -150+leftGeom, y: 800 } },

  // Elemente de Trigonometrie
  { id: '91', data: { label: 'Trigonometrie' }, position: { x: 150, y: 200 } },
    { id: '92', data: { label: 'Definiții funcții trigonometrice' }, position: { x: 150, y: 300 } },
    { id: '93', data: { label: 'Relații fundamentale trigonometrice' }, position: { x: 150, y: 400 } },
    { id: '94', data: { label: 'Valori notabile' }, position: { x: 150, y: 500 } },
    { id: '95', data: { label: 'Ecuații trigonometrice simple' }, position: { x: 150, y: 500 } },

  // Elemente de statistică și probabilități
  { id: '96', data: { label: 'Statistica și probabilități' }, position: { x: 450, y: 200 } },
    { id: '97', data: { label: 'Noțiuni de bază despre statistică' }, position: { x: 450, y: 300 } },
    { id: '98', data: { label: 'Medii, mod, mediană, dispersie' }, position: { x: 450, y: 400 } },
    { id: '99', data: { label: 'Probabilități. Experimente aleatoare' }, position: { x: 450, y: 500 } },
]);

const edges: Edge[] = [
  { id: 'e60-61', source: '60', target: '61' },

  // Clasa a IX-a -> capitole
  { id: 'e61-62', source: '61', target: '62' },
  { id: 'e61-80', source: '61', target: '80' },
  { id: 'e61-91', source: '61', target: '91' },
  { id: 'e61-96', source: '61', target: '96' },

  // Aritmetică și Algebra
  { id: 'e62-63', source: '62', target: '63' },
  { id: 'e63-64', source: '63', target: '64' },
    { id: 'e64-65', source: '64', target: '65' },
    { id: 'e64-66', source: '64', target: '66' },
    { id: 'e64-67', source: '64', target: '67' },
  { id: 'e65-68', source: '65', target: '68' },
  { id: 'e66-68', source: '66', target: '68' },
  { id: 'e67-68', source: '67', target: '68' },
    { id: 'e68-69', source: '68', target: '69' },
    { id: 'e68-70', source: '68', target: '70' },
  { id: 'e69-71', source: '69', target: '71' },
  { id: 'e70-71', source: '70', target: '71' },
  { id: 'e71-72', source: '71', target: '72' },
    { id: 'e72-73', source: '72', target: '73' },
    { id: 'e72-74', source: '72', target: '74' },
  { id: 'e73-75', source: '73', target: '75' },
  { id: 'e74-75', source: '74', target: '75' },
    { id: 'e75-76', source: '75', target: '76' },
    { id: 'e75-77', source: '75', target: '77' },
    { id: 'e75-78', source: '75', target: '78' },
  { id: 'e76-79', source: '76', target: '79' },
  { id: 'e77-79', source: '77', target: '79' },
  { id: 'e78-79', source: '78', target: '79' },

  // Geometrie
  { id: 'e80-81', source: '80', target: '81' },
    { id: 'e81-82', source: '81', target: '82' },
    { id: 'e81-83', source: '81', target: '83' },
    { id: 'e81-84', source: '81', target: '84' },
  { id: 'e82-85', source: '82', target: '85' },
  { id: 'e83-85', source: '83', target: '85' },
  { id: 'e84-85', source: '84', target: '85' },
    { id: 'e85-86', source: '85', target: '86' },
    { id: 'e85-87', source: '85', target: '87' },
    { id: 'e85-88', source: '85', target: '88' },
  { id: 'e86-89', source: '86', target: '89' },
  { id: 'e87-89', source: '87', target: '89' },
  { id: 'e88-89', source: '88', target: '89' },
  { id: 'e89-90', source: '89', target: '90' },

  // Trigonometrie
  { id: 'e91-92', source: '91', target: '92' },
  { id: 'e92-93', source: '92', target: '93' },
  { id: 'e93-94', source: '93', target: '94' },
  { id: 'e94-95', source: '94', target: '95' },

  // Statistica și probabilități
  { id: 'e96-97', source: '96', target: '97' },
  { id: 'e97-98', source: '97', target: '98' },
  { id: 'e98-99', source: '98', target: '99' },
];

export default function MatematicaMindmap() {
  return <Mindmap userNodes={nodes} userEdges={edges} />;
}
