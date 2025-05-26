import React, { useState, useCallback } from 'react';
import ReactFlow, {
  MiniMap,
  Controls,
  Background
} from 'react-flow-renderer';
import type { Node, Edge } from 'react-flow-renderer';

interface MindmapProps {
  userNodes: Node[],
  userEdges: Edge[];
}

const Mindmap: React.FC<MindmapProps> = ({ userNodes, userEdges }) => {


  const onNodeClick = useCallback((_event : React.MouseEvent, node : Node) => {
    if (node.data?.url && node.data.url !== '#') {
      window.open(node.data.url, '_blank');
    }
  }, []);

  return (
    <div style={{ height: '100vh', zIndex: 0 }}>
      <ReactFlow
        nodes={userNodes}
        edges={userEdges}
        onNodeClick={onNodeClick}
        fitView
        style={{ width: '100%', height: '100%' }}
      >
        <MiniMap />
        <Controls />
        <Background />
      </ReactFlow>
    </div>
  );
};


export default Mindmap;

