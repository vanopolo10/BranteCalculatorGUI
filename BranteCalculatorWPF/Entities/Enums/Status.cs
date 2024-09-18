using BranteCalculatorWPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculator.Entities.Enums
{
    public class Status : LocalizibleObject
    {
        //Pseudo enum to store names
        public static readonly Status GRATEFUL = new Status("CHARACTER_STATUS_GENERAL_GRATEFUL");
        public static readonly Status SAVED = new Status("CHARACTER_STATUS_SOPHIA_SAVED");
        public static readonly Status DIED_HER_FIRST_DEATH = new Status("CHARACTER_STATUS_SOPHIA_DIED_HER_FIRST_DEATH");
        public static readonly Status BAD_BLOOD = new Status("CHARACTER_STATUS_STEPHAN_BRANTE_BAD_BLOOD");
        public static readonly Status REMEMBERS_YOU = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_REMEMBERS_YOU");
        public static readonly Status AQUAINTED = new Status("CHARACTER_STATUS_JEANNE_AQUAINTED");
        public static readonly Status TRUSTING = new Status("CHARACTER_STATUS_SOPHIA_AQUAINTED");
        public static readonly Status MERCILESS = new Status("CHARACTER_STATUS_SOPHIA_MERCILESS");
        public static readonly Status EMBITTERED = new Status("CHARACTER_STATUS_SOPHIA_EMBITTERED");
        public static readonly Status TRUE_DEATH = new Status("CHARACTER_STATUS_GENERAL_TRUE_DEATH");
        public static readonly Status BOUND_BY_FRIENDSHIP = new Status("CHARACTER_STATUS_TOMMAS_GERRO_BOUND_BY_FRIENDSHIP");
        public static readonly Status REMAINED_FRIENDS = new Status("CHARACTER_STATUS_TOMMAS_GERRO_REMAINED_FRIENDS");
        public static readonly Status SEVERED_ALL_TIES = new Status("CHARACTER_STATUS_GENERAL_SEVERED_ALL_TIES");
        public static readonly Status ACQUAINTED = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_ACQUAINTED");
        public static readonly Status ILL_DISPOSED = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_ILL_DISPOSED");
        public static readonly Status INTRIGUED = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_INTRIGUED");
        public static readonly Status JOINED_A_TROUPE = new Status("CHARACTER_STATUS_AYLIS_JOINED_A_TROUPE");
        public static readonly Status STEADFAST_IN_FAITH = new Status("CHARACTER_STATUS_JEANNE_STEADFAST_IN_FAITH");
        public static readonly Status ZEALOUS = new Status("CHARACTER_STATUS_JEANNE_ZEALOUS");
        public static readonly Status WAVERING = new Status("CHARACTER_STATUS_JEANNE_WAVERING");
        public static readonly Status GROWN_CLOSE = new Status("CHARACTER_STATUS_GENERAL_GROWN_CLOSE");
        public static readonly Status MASTER = new Status("CHARACTER_STATUS_FATHER_ULRICH_MASTER");
        public static readonly Status YOUR_PATRON = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_YOUR_PATRON");
        public static readonly Status A_PROMISE_IS_MADE = new Status("CHARACTER_STATUS_FATHER_LENNART_A_PROMISE_IS_MADE");
        public static readonly Status SCORNED = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_SCORNED");
        public static readonly Status SAW_YOUR_LOYALTY = new Status("CHARACTER_STATUS_FELIPE_EL_FERRO_SAW_YOUR_LOYALTY");
        public static readonly Status SECRET_PLOT = new Status("CHARACTER_STATUS_GENERAL_SECRET_PLOT");
        public static readonly Status IN_JEOPARDY = new Status("CHARACTER_STATUS_MAYER_EGMONT_IN_JEOPARDY");
        public static readonly Status MADE_A_DEAL = new Status("CHARACTER_STATUS_GENERAL_MADE_A_DEAL");
        public static readonly Status THE_PROMISE = new Status("CHARACTER_STATUS_AUGUSTIN_EL_BORNE_THE_PROMISE");
        public static readonly Status PENANCE = new Status("CHARACTER_STATUS_FATHER_LENNART_PENANCE");
        public static readonly Status AT_HOME = new Status("CHARACTER_STATUS_GENERAL_AT_HOME");
        public static readonly Status BETHROTHED = new Status("CHARACTER_STATUS_GLORIA_BETHROTHED");
        public static readonly Status BETRAYED = new Status("CHARACTER_STATUS_GENERAL_BETRAYED");
        public static readonly Status SHE_IS_BETRAYED = new Status("CHARACTER_STATUS_SOPHIA_BETRAYED");
        public static readonly Status DISGRACED = new Status("CHARACTER_STATUS_STEPHAN_BRANTE_DISGRACED");
        public static readonly Status DISHONORED = new Status("CHARACTER_STATUS_DORIUS_OTTON_DISHONORED");
        public static readonly Status DUEL_IMPENDING = new Status("CHARACTER_STATUS_STEPHAN_BRANTE_DUEL_IMPENDING");
        public static readonly Status EXILED = new Status("CHARACTER_STATUS_TOMMAS_GERRO_EXILED");
        public static readonly Status FREED = new Status("CHARACTER_STATUS_FATHER_MARK_FREED");
        public static readonly Status IMPRISONED = new Status("CHARACTER_STATUS_FATHER_MARK_IMPRISONED");
        public static readonly Status IN_DANGER = new Status("CHARACTER_STATUS_TOMMAS_GERRO_IN_DANGER");
        public static readonly Status IN_HIDING = new Status("CHARACTER_STATUS_TOMMAS_GERRO_IN_HIDING");
        public static readonly Status IN_HIDING_ESCAPE = new Status("CHARACTER_STATUS_GENERAL_IN_HIDING_ESCAPE");
        public static readonly Status KILLED_IN_A_DUEL = new Status("CHARACTER_STATUS_GENERAL_KILLED_IN_A_DUEL");
        public static readonly Status RESCUED = new Status("CHARACTER_STATUS_TOMMAS_GERRO_RESCUED");
        public static readonly Status RECRUITED = new Status("CHARACTER_STATUS_NATHAN_BRANTE_RECRUITED");
        public static readonly Status ARRESTED = new Status("CHARACTER_STATUS_MAYER_EGMONT_ARRESTED");
        public static readonly Status BETRAYED_BY_YOU = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_BETRAYED_BY_YOU");
        public static readonly Status CONSUMED_BY_DESPAIR = new Status("CHARACTER_STATUS_NATHAN_BRANTE_CONSUMED_BY_DESPAIR");
        public static readonly Status HOPEFUL = new Status("CHARACTER_STATUS_GENERAL_HOPEFUL");
        public static readonly Status LOVER = new Status("CHARACTER_STATUS_SOPHIA_LOVER");
        public static readonly Status LEADING_THE_REVOLT = new Status("CHARACTER_STATUS_GENERAL_LEADING_THE_REVOLT");
        public static readonly Status ENEMY = new Status("CHARACTER_STATUS_REMY_EL_VERMAN_ENEMY");
        public static readonly Status MARRIED = new Status("CHARACTER_STATUS_GLORIA_MARRIED");
        public static readonly Status FLED = new Status("CHARACTER_STATUS_GENERAL_FLED");
        public static readonly Status NEVER_TO_RETURN = new Status("CHARACTER_STATUS_STEPNAN_BRANTE_NEVER_TO_RETURN");
        public static readonly Status SPIRITUAL_BOND = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_SPIRITUAL_BOND");
        public static readonly Status SUCCUMBED_TO_ILLNESS = new Status("CHARACTER_STATUS_LYDIA_BRANTE_SUCCUMBED_TO_ILLNESS");
        public static readonly Status DIED_BY_YOUR_HAND = new Status("CHARACTER_STATUS_FATHER_ULRICH_DIED_BY_YOUR_HAND");
        public static readonly Status EXECUTED = new Status("CHARACTER_STATUS_FATHER_LENNART_EXECUTED");
        public static readonly Status HE_IS_ENEMY = new Status("CHARACTER_STATUS_REMY_EL_VERMAN_ENEMY");
        public static readonly Status DISTRUSTFUL = new Status("CHARACTER_STATUS_SOPHIA_DISTRUSTFUL");
        public static readonly Status ALLY = new Status("CHARACTER_STATUS_SOPHIA_ALLY");
        public static readonly Status SHE_IS_EXECUTED = new Status("CHARACTER_SOPHIA_EXECUTED");
        public static readonly Status REBEL = new Status("CHARACTER_STATUS_GENERAL_REBEL");
        public static readonly Status DEFENDER_OF_THE_EMPIRE = new Status("CHARACTER_STATUS_GENERAL_DEFENDER_OF_THE_EMPIRE");
        public static readonly Status PATRIARCH = new Status("CHARACTER_STATUS_FATHER_LENNART_PATRIARCH");
        public static readonly Status CAPTIVE = new Status("CHARACTER_STATUS_GENERAL_CAPTIVE");
        public static readonly Status BROUGHT_BACK = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_BROUGHT_BACK");
        public static readonly Status LEFT_A_TRACE = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_LEFT_A_TRACE");
        public static readonly Status ESCAPED_THE_WORLD = new Status("CHARACTER_STATUS_OCTAVIA_MILANIDAS_ESCAPED_THE_WORLD");
        public static readonly Status DEFEATED = new Status("CHARACTER_STATUS_GENERAL_DEFEATED");
        public static readonly Status RIGHTEOUS = new Status("CHARACTER_STATUS_JEANNE_RIGHTEOUS");
        public static readonly Status NEW_BELIEVER = new Status("CHARACTER_STATUS_JEANNE_RIGHTEOUS");
        public static readonly Status DOOMED_FOR_HER_SIN = new Status("CHARACTER_STATUS_JEANNE_DOOMED_FOR_HER_SIN");
        public static readonly Status BURIED_ALIVE = new Status("CHARACTER_STATUS_JEANNE_BURIED_ALIVE");
        public static readonly Status RECONCILED = new Status("CHARACTER_STATUS_DORIUS_OTTON_RECONCILED");
        public static readonly Status SENTENCED = new Status("CHARACTER_STATUS_DORIUS_OTTON_SENTENCED");
        public static readonly Status PROPHET = new Status("CHARACTER_STATUS_NATHAN_BRANTE_PROPHET");

        private Status(string name) : base(name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Status otherStatus)
            {
                return Name.Equals(otherStatus.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
