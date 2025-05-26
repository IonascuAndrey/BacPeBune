// App.tsx
import React from 'react';
import MatematicaMindmap from './components/MatematicaMindmap';
import InformaticaMindmap from './components/InformaticaMindmap';

function App() {
  const params = new URLSearchParams(window.location.search);
  const subject = params.get('subject');

  return (
    <div>
      {subject === 'matematica' && <MatematicaMindmap />}
      {subject === 'informatica' && <InformaticaMindmap />}
    </div>
  );
}

export default App;
