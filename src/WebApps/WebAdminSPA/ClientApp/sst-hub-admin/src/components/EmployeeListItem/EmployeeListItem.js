const EmployeeListItem = ({ createdAt, firstName, lastName, position }) => {
  return (
    <tr>
      <td>{createdAt}</td>
      <td>{firstName}</td>
      <td>{lastName}</td>
      <td>{position}</td>
    </tr>
  );
};

export default EmployeeListItem;
