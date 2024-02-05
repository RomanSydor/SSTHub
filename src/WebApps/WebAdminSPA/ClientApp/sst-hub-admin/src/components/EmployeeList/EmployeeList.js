import { useEffect, useState } from "react";
import employeeApi from "../../services/employees";
import EmployeeListItem from "../EmployeeListItem";

const EmployeeList = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    getEmployees();
  }, []);

  const getEmployees = async () => {
    try {
      const response = await employeeApi.getEmployees();

      setEmployees((prevEmployees) => [...prevEmployees, ...response]);
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>createdAt</th>
            <th>firstName</th>
            <th>lastName</th>
            <th>position</th>
          </tr>
        </thead>
        <tbody>
          {employees &&
            employees.map(
              ({ id, createdAt, firstName, lastName, position }) => (
                <EmployeeListItem
                  key={id}
                  id={id}
                  createdAt={createdAt}
                  firstName={firstName}
                  lastName={lastName}
                  position={position}
                />
              )
            )}
        </tbody>
      </table>
    </div>
  );
};

export default EmployeeList;
