import { Button } from "../../atoms";
import styles from '../../atoms/Button/Button.module.css';

const Square = ({ value, onClick }) => {
  return (
    <Button className={styles.squareButton} onClick={onClick} label={value} />
  );
};

export default Square;