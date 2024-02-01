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
            <th>id</th>
            <th>isActive</th>
            <th>createdAt</th>
            <th>firstName</th>
            <th>lastName</th>
            <th>email</th>
            <th>phone</th>
            <th>position</th>
            <th>hubId</th>
          </tr>
        </thead>
        <tbody>
          {employees &&
            employees.map(
              ({
                id,
                isActive,
                createdAt,
                firstName,
                lastName,
                email,
                phone,
                position,
                hubId,
              }) => (
                <EmployeeListItem
                  key={id}
                  id={id}
                  isActive={isActive}
                  createdAt={createdAt}
                  firstName={firstName}
                  lastName={lastName}
                  email={email}
                  phone={phone}
                  position={position}
                  hubId={hubId}
                />
              )
            )}
        </tbody>
      </table>
    </div>
  );
};

export default EmployeeList;
