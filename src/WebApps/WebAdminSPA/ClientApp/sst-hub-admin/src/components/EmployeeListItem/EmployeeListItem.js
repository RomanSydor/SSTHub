const EmployeeListItem = ({
  id,
  isActive,
  createdAt,
  firstName,
  lastName,
  email,
  phone,
  position,
  hubId,
}) => {
  return (
    <tr>
      <td>{id}</td>
      <td>{isActive}</td>
      <td>{createdAt}</td>
      <td>{firstName}</td>
      <td>{lastName}</td>
      <td>{email}</td>
      <td>{phone}</td>
      <td>{position}</td>
      <td>{hubId}</td>
    </tr>
  );
};

export default EmployeeListItem;
