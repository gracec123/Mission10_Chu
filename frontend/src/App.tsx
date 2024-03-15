import React from 'react';
import './App.css';
import Header from './Header';
import BowlingList from './Bowling/BowlingList';

function App() {
  // Main component of the application
  return (
    <div className="App">
      <Header title="Bowling League Database" />
      <BowlingList />
    </div>
  );
}

export default App;
