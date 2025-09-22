import React from "react";
import './Label.module.css';

const Label = ({ text, className }) => {
  return <label className={className}>{text}</label>;
};

export default Label;
