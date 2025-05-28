// MatematicaMindmap.tsx
import React from 'react';
import Mindmap from './Mindmap';
import type { Node, Edge } from 'react-flow-renderer';

const nodes: Node[] = [
  { id: '1', data: { label: 'Funcții', url: "/Lectii/Index?id=1" }, position: { x: 250, y: 5 } },
  { id: '2', data: { label: 'Șiruri', url: "/Lectii/Index?id=2" }, position: { x: 100, y: 100 } },
  { id: '3', data: { label: 'BlaBla', url: "/Lectii/Index?id=3" }, position: { x: 400, y: 100 } },
];

const edges: Edge[] = [
  { id: 'e1-2', source: '1', target: '2', animated: true },
  { id: 'e1-3', source: '1', target: '3' },
];

export default function MatematicaMindmap() {
  return <Mindmap userNodes={nodes} userEdges={edges} />;
}
