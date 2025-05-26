export type NodeData = {
  id: string;
  label: string;
  position: { x: number; y: number };
  url?: string;
  backgroundColor?: string;
  color?: string;
};

export type EdgeData = {
  id: string;
  source: string;
  target: string;
};