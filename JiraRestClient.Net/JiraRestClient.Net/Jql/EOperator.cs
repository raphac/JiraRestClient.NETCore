﻿namespace JiraRestClient.Net.Jql
{
    public class EOperator
    {
        /*
         * The "=" operator is used to search for issues where the value of the specified field exactly matches the specified value.
         * (Note: cannot be used with text fields; see the CONTAINS operator instead.) To find issues where the value of a specified
         * field exactly matches multiple values, use multiple "=" statements with the AND operator.
         */
        public static readonly EOperator EQUALS = new EOperator("=");


        /*
           * The "!=" operator is used to search for issues where the value of the specified field does not match the specified value.
           * (Note: cannot be used with text fields; see the DOES NOT MATCH ("!~") operator instead.) Note that typing field != value
           * is the same as typing NOT field = value, and that field != EMPTY is the same as field IS_NOT EMPTY.
           * The "!=" operator will not match a field that has no value (i.e. a field that is empty). For example, component != fred
           * will only match issues that have a component and the component is not "fred". To find issues that have a component other
           * than "fred" or have no component, you would need to type: component != fred or component is empty.
           */
        public static readonly EOperator NOT_EQUALS = new EOperator("!=");

        /*
         * The ">" operator is used to search for issues where the value of the specified field is greater than the specified value.
         * Cannot be used with text fields. Note that the ">" operator can only be used with fields which support ordering
         * (e.g. date fields and version fields). To see a field's supported operators, check the individual field reference.
         */
        public static readonly EOperator GREATER_THAN = new EOperator(">");

        /*
         * The ">=" operator is used to search for issues where the value of the specified field is greater than or equal to the
         * specified value. Cannot be used with text fields. Note that the ">=" operator can only be used with fields which support
         * ordering (e.g. date fields and version fields). To see a field's supported operators, check the individual field reference.
         */
        public static readonly EOperator GREATER_THAN_EQUALS = new EOperator(">=");

        /*
         * The < operator is used to search for issues where the value of the specified field is less than the specified value.
         * Cannot be used with text fields.Note that the < operator can only be used with fields which support ordering (e.g. date fields and version fields).
         * To see a fields supported operators, check the individual field reference.
         */
        public static readonly EOperator LESS_THAN = new EOperator("<");

        /*
         * The <= operator is used to search for issues where the value of the specified field is less than or equal to than the
         * specified value. Cannot be used with text fields. Note that the "<=" operator can only be used with fields which support
         * ordering (e.g. date fields and version fields). To see a field's supported operators, check the individual field reference.
         */
        public static readonly EOperator LESS_THAN_EQUALS = new EOperator("<=");

        /*
         * The "IN" operator is used to search for issues where the value of the specified field is one of multiple specified values. The
         * values are specified as a comma-delimited list, surrounded by parentheses.
         * Using "IN" is equivalent to using multiple EQUALS (=) statements, but is shorter and more convenient. That is, typing reporter
         * IN (tom, jane, harry) is the same as typing reporter = "tom" OR reporter = "jane" OR reporter = "harry".
         */
        public static readonly EOperator IN = new EOperator("in");

        /*
         * The "NOT IN" operator is used to search for issues where the value of the specified field is not one of multiple specified values.
         * Using "NOT IN" is equivalent to using multiple NOT_EQUALS (!=) statements, but is shorter and more convenient. That is, typing
         * reporter NOT IN (tom, jane, harry) is the same as typing reporter != "tom" AND reporter != "jane" AND reporter != "harry". The "NOT IN"
         * operator will not match a field that has no value (i.e. a field that is empty). For example, assignee not in (jack,jill) will only
         * match issues that have an assignee and the assignee is not "jack" or "jill". To find issues that are assigned to someone other than
         * "jack" or "jill" or are unassigned, you would need to type: assignee not in (jack,jill) or assignee is empty.
         */
        public static readonly EOperator NOT_IN = new EOperator("not in");

        /*
         * The "~" operator is used to search for issues where the value of the specified field matches the specified value (either an exact match or
         * a "fuzzy" match — see examples below). For use with text fields only, i.e.:
         * <li>Summary</li>
         * <li>Description</li>
         * <li>Environment</li>
         * <li>Comments</li>
         */
        public static readonly EOperator CONTAINS = new EOperator("~");

        /*
         * The "!~" operator is used to search for issues where the value of the specified field is not a "fuzzy" match for the specified value.
         * For use with text fields only, i.e.:
         * <li>Summary</li>
         * <li>Description</li>
         * <li>Environment</li>
         * <li>Comments</li>
         */
        public static readonly EOperator DOES_NOT_CONTAIN = new EOperator("!~");

        /*
         * The "IS" operator can only be used with EMPTY or NULL. That is, it is used to search for issues where the specified field has no value.
         * Note that not all fields are compatible with this operator; see the individual field reference for details.
         */
        public static readonly EOperator IS = new EOperator("is");

        /*
         * The "IS NOT" operator can only be used with EMPTY or NULL. That is, it is used to search for issues where the specified field has a value.
         * Note that not all fields are compatible with this operator; see the individual field reference for details.
         */
        public static readonly EOperator IS_NOT = new EOperator("is not");

        /*
         * The "WAS" operator is used to find issues that currently have, or previously had, the specified value for the specified field.
         * This operator has the following optional predicates:
         * <li>AFTER "date"</li>
         * <li>BEFORE "date"</li>
         * <li>BY "username"</li>
         * <li>DURING ("date1","date2")</li>
         * <li>ON "date"</li>
         * <br>
         * This operator will match the value name (e.g. "Resolved"), which was configured in your system at the time that the field was changed.
         * This operator will also match the value ID associated with that value name too — that is, it will match "4" as well as "Resolved".
         * (Note: This operator can be used with the Assignee, Fix Version, Priority,  Reporter, Resolution and Status fields only.)
         */
        public static readonly EOperator WAS = new EOperator("was");

        /*
         * The "WAS IN" operator is used to find issues that currently have, or previously had, any of multiple specified values for the specified field.
         * The values are specified as a comma-delimited list, surrounded by parentheses. Using "WAS IN" is equivalent to using multiple WAS statements,
         * but is shorter and more convenient. That is, typing status WAS IN ('Resolved', 'Closed') is the same as typing status WAS "Resolved" OR status WAS "Closed".
         * <li>AFTER "date"</li>
         * <li>BEFORE "date"</li>
         * <li>BY "username"</li>
         * <li>DURING ("date1","date2")</li>
         * <li>ON "date"</li>
         * <br>
         * This operator will match the value name (e.g. "Resolved"), which was configured in your system at the time that the field was changed. This
         * operator will also match the value ID associated with that value name too — that is, it will match "4" as well as "Resolved". (Note: This
         * operator can be used with the Assignee, Fix Version, Priority,  Reporter, Resolution and Status fields only.)
         */
        public static readonly EOperator WAS_IN = new EOperator("was in");

        /*
         * The "WAS NOT IN" operator is used to search for issues where the value of the specified field has never been one of multiple specified values.
         * Using "WAS NOT IN" is equivalent to using multiple WAS_NOT statements, but is shorter and more convenient. That is, typing status
         * WAS NOT IN ("Resolved","In Progress") is the same as typing status WAS NOT "Resolved" AND status WAS NOT "In Progress".
         * This operator has the following optional predicates:
         * <li>AFTER "date"</li>
         * <li>BEFORE "date"</li>
         * <li>BY "username"</li>
         * <li>DURING ("date1","date2")</li>
         * <li>ON "date"</li>
         * <br>
         * This operator will match the value name (e.g. "Resolved"), which was configured in your system at the time that the field was changed.
         * This operator will also match the value ID associated with that value name too — that is, it will match "4" as well as "Resolved".
         * (Note: This operator can be used with the Assignee, Fix Version, Priority,  Reporter, Resolution and Status fields only.)
         */
        public static readonly EOperator WAS_NOT_IN = new EOperator("was not in");

        /*
         * The "WAS NOT" operator is used to find issues that have never had the specified value for the specified field.
         * This operator has the following optional predicates:
         * <li>AFTER "date"</li>
         * <li>BEFORE "date"</li>
         * <li>BY "username"</li>
         * <li>DURING ("date1","date2")</li>
         * <li>ON "date"</li>
         * <br>
         * This operator will match the value name (e.g. "Resolved"), which was configured in your system at the time that the field was changed.
         * This operator will also match the value ID associated with that value name too — that is, it will match "4" as well as "Resolved".
         * (Note: This operator can be used with the Assignee, Fix Version, Priority,  Reporter, Resolution and Status fields only.)
         */
        public static readonly EOperator WAS_NOT = new EOperator("was not");

        /*
         * The "CHANGED" operator is used to find issues that have a value which had changed for the specified field.
         * This operator has the following optional predicates:
         * <li>AFTER "date"</li>
         * <li>BEFORE "date"</li>
         * <li>BY "username"</li>
         * <li>DURING ("date1","date2")</li>
         * <li>ON "date"</li>
         * <li>FROM "oldvalue"</li>
         * <li>TO "newvalue"</li>
         * <br>
         * (Note: This operator can be used with the Assignee, Fix Version, Priority, Reporter, Resolution and Status fields only.)
         */
        public static readonly EOperator CHANGED = new EOperator("changed");
        public static readonly EOperator AFTER = new EOperator("after");
        public static readonly EOperator BEFORE = new EOperator("before");
        public static readonly EOperator BY = new EOperator("by");
        public static readonly EOperator FROM = new EOperator("from");
        public static readonly EOperator ON = new EOperator("on");
        public static readonly EOperator TO = new EOperator("to");

        /*
         * The operator.
         */
        public string eoperator { get; set; }

        /*
         * Instantiates a new operator.
         *
         * @param eoperator the name of the operator
         */
        public EOperator(string eoperator)
        {
            this.eoperator = eoperator;
        }


        public override string ToString()
        {
            return eoperator;
        }

    }
}
