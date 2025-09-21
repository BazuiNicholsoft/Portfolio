import React from "react";
import styles from './Button.module.css';

const Button = ({ label, className, onClick }) => {
  const buttonClass = className ? className : styles.atomButton;
  return (
    <button className={buttonClass} onClick={onClick}>
      {label}
    </button>
  );
};

export default Button;
