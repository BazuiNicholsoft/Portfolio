import { Button } from "../../atoms";
import styles from '../../atoms/Button/Button.module.css';

const Square = ({ value, className, onClick }: { value: string; className?: string; onClick: () => void }) => {
  const classes = [styles.squareButton, className].filter(Boolean).join(' ');
  return (
    <Button className={classes} onClick={onClick} label={value} />
  );
};

export default Square;