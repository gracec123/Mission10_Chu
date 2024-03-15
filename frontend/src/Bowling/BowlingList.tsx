import { useState, useEffect } from 'react';
import { Bowling } from '../types/Bowling';

function BowlingList() {
  // State to store bowling data
  const [BowlingData, setBowlingData] = useState<Bowling[]>([]);

  // Fetch data from the API when the component mounts
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5113/bowling');
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const bowlers = await response.json();
        setBowlingData(bowlers);
      } catch (error) {
        console.error('There was an error!', error);
      }
    };

    fetchData();
  }, []); // This ensures fetchData is only called once when the component mounts

  return (
    <>
      <div className="row">
        <h4 className="text-center">The Best Bowling Team</h4>
      </div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Bowler's Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
            <th>Team Name</th>
          </tr>
        </thead>
        <tbody>
          {BowlingData.map((bowler) => (
            <tr key={bowler.bowlerId}>
              <td>{bowler.bowlerName}</td>
              <td>{bowler.bowlerAddress}</td>
              <td>{bowler.bowlerCity}</td>
              <td>{bowler.bowlerState}</td>
              <td>{bowler.bowlerZip}</td>
              <td>{bowler.bowlerPhoneNumber}</td>
              <td>{bowler.teamName}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlingList;
