import React, { useState } from 'react';
import './App.css';
import calculateWinner from './CalculateWinner';


function App() {
  const [squares, setSquares] = useState(Array(9).fill(null));
  const [xIsNext, setXIsNext] = useState(true);

  const handleClick = (i) => {
    //creaza copie state curent
    const newSquares = squares.slice();
    //daca ia winner nu mai poti face click sau daca valoare din newSquares[i] nu ii null
    if (calculateWinner(newSquares) || newSquares[i]) {
      return;
    }
    //schimba valuarea din buton in functie de tura
    newSquares[i] = xIsNext ? 'X' : 'O';
    //update square
    setSquares(newSquares);
     //schimba rand 
    setXIsNext(!xIsNext);
  };

  const renderSquare = (i) => {
    return (
      <button className="square" onClick={() => handleClick(i)}>
        {squares[i]}
      </button>
    );
  };

  const winner = calculateWinner(squares);
  let status;
  if (winner) {
    status = 'Winner: ' + winner;
  } else if (squares.every((square) => square)) {
    status = 'Draw! No winner.';
  } else {
    status = 'Next player: ' + (xIsNext ? 'X' : 'O');
  }

  return (
    <div className="game">
      <div className="game-board">
        <div className="board-row">
          {renderSquare(0)}
          {renderSquare(1)}
          {renderSquare(2)}
        </div>
        <div className="board-row">
          {renderSquare(3)}
          {renderSquare(4)}
          {renderSquare(5)}
        </div>
        <div className="board-row">
          {renderSquare(6)}
          {renderSquare(7)}
          {renderSquare(8)}
        </div>
      </div>
      <div className="game-info">
        <div>{status}</div>
      </div>
    </div>
  );
}



export default App;



