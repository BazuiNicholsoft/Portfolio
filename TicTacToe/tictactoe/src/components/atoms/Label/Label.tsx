import React from "react";
import './Label.module.css';

const Label = ({ text, className }: { text: string; className?: string }) => {
  return <label className={className}>{text}</label>;
};

export default Label;
