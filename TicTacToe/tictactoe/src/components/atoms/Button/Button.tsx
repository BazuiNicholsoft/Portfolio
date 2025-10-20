import styles from './Button.module.css';

const Button = ({ label, className, onClick }: { label: string; className?: string; onClick: () => void }) => {
  const buttonClass = className ? className : styles.atomButton;
  return (
    <button className={buttonClass} onClick={onClick}>
      {label}
    </button>
  );
};

export default Button;
