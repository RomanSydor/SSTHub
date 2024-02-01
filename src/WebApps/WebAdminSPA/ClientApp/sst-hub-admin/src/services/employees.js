import axios from "axios";

const getEmployees = () => {
  return axios.get("api/Employee").then(({ data }) => data);
};

const employeeApi = {
  getEmployees,
};

export default employeeApi;
