import axios from "axios";

import localConfig from "./config.local";

const axiosConfig = {
  baseURL: localConfig.baseURL,
};

const axiosInit = () => {
  axios.defaults.baseURL = axiosConfig.baseURL;
};

export default axiosInit();
