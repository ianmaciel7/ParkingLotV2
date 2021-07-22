import React, { useState, useEffect } from "react";
import API from "../services/API";

export const useReportGet = () => {
  const initialState = {
    ListPaid: [{}],
    ListUnpaid: [{}],
  };

  const [report, setReport] = useState(initialState);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(false);

  const getReport = async () => {
    setLoading(true);
    try {
      setError(false);

      const response = await API.getReport();
      //console.log(response);
      setReport(response);
    } catch (error) {
      setError(true);
    }
    setLoading(false);
  };

  useEffect(async () => {
    await getReport();
  }, []);

  return {
    report,
    loading,
    error,
  };
};
