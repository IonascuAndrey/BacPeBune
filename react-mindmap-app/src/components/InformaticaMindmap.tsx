// InformaticaMindmap.tsx
import React from 'react';
import Mindmap from './Mindmap';
import type { Node, Edge } from 'react-flow-renderer';

const nodes: Node[] = [
  { id: '4', data: { label: 'React', url: 'https://x.com' }, position: { x: 500, y: 5 } },
  { id: '5', data: { label: 'Dotnet', url: '#' }, position: { x: 0, y: 0 } },
];

const edges: Edge[] = [
  { id: 'e4-5', source: '4', target: '5', animated: true },
];

export default function InformaticaMindmap() {
  return <Mindmap userNodes={nodes} userEdges={edges} />;
}
