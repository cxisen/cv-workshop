import { Experience } from "../../types/types";
import akersgataImage from "../../assets/akersgata.jpg";
import styles from "./DetailedExperience.module.css";
import { ExperienceChip } from "./ExperienceChip";
import { CxIcon } from "@computas/designsystem/icon/react";

const DetailedExperience = ({ experience, close }: { experience: Experience, close: () => void }) => {
    function getMonth(date: string) {
        const dateObj = new Date(date);
        const month = dateObj.toLocaleDateString("nb-NO", { month: "long" });
        const year = dateObj.getFullYear();
        return `${month.charAt(0).toUpperCase() + month.slice(1)} ${year}`;
    }

    return (
        <>
            <div className={styles.close} onClick={close}>
                <div className="cx-chip cx-ml-6">
                    <CxIcon name="close" size="4" />
                </div>
            </div>
            <div className={styles.container} onClick={(e) => {
                e.preventDefault();
                e.stopPropagation();
            }}>
                <img
                    className={styles.image}
                    src={experience.imageUrl || akersgataImage}
                    alt={experience.title}
                />
                <div className={styles.chip}>
                    <ExperienceChip type={experience.type} />
                </div>
                <div className={styles.info}>
                    <p className={styles.keyInfo}>
                        <CxIcon name="calendar" size="4" />{" "}
                        {experience.startDate && getMonth(experience.startDate)} -{" "}
                        {experience.endDate ? getMonth(experience.endDate) : "d.d"}
                    </p>
                    <p className={styles.keyInfo}>
                        <CxIcon name="location" size="4" />{" "}
                        {experience.company ?? "Selvstendig arbeid"}
                    </p>
                    <p className={styles.eventTitle}>{experience.title}</p>
                    <p>{experience.description}</p>
                    <p>{experience.role}</p>
                </div>
            </div>
        </>
    )
}

export default DetailedExperience;