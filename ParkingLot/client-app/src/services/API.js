import { API_URL } from "../helpers/config";

function defaultConfig(
  method,
  contentType = "application/json; charset=utf-8"
) {
  return {
    method: method.toUpperCase(),
    
    headers: {
      Accept: contentType,
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "GET, PUT, POST, DELETE, HEAD, OPTIONS",
      "Access-Control-Expose-Headers": "*"
    },
  };
}

const apiSettings = {
  getReport: async () => {
    const endpoint = `${API_URL}/Report`;

    return await fetch(endpoint, {
      ...defaultConfig("get"),
    }).then((response) => {
      if (response.ok) return response.json();
      else throw response.cod;
    });
  },

  postTicket: async (ticket) => {
    const endpoint = `${API_URL}/Ticket`;

    return await fetch(endpoint, {
      ...defaultConfig("post"),
      body: JSON.stringify(ticket),
    }).then((response) => {
      return response.status;
    });
  },

  patchParkingSpace: async (ticketId) => {
    const endpoint = `${API_URL}/ParkingSpace/${ticketId}`;

    return await fetch(endpoint, {
      ...defaultConfig("patch", "text/plain"),
    }).then((response) => {
      return response.status;
    });
  },

  patchTicket: async (ticketId) => {
    const endpoint = `${API_URL}/Ticket/${ticketId}`;

    return await fetch(endpoint, {
      ...defaultConfig("patch", "text/plain"),
    }).then((response) => {
      return response.status;
    });
  },
};

export default apiSettings;
