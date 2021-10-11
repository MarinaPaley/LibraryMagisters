namespace Domain
{
    using System;
    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
        public Author(Guid id, string familyName, string firstName, string middleName = null)
        {
            Id = id;
            var trimmedName = firstName?.Trim();
            if (string.IsNullOrEmpty(trimmedName) == null)
                throw new ArgumentNullException(nameof(firstName));
            FirstName = firstName;

            trimmedName = familyName?.Trim();
            if (string.IsNullOrEmpty(trimmedName) == null)
                throw new ArgumentNullException(nameof(familyName));
            FamilyName = familyName;

            trimmedName = middleName?.Trim();
            if (string.IsNullOrEmpty(trimmedName) != null)
                MiddleName = middleName;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FamilyName { get; protected set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; protected set; }

        /// <summary>
        /// Полное Имя.
        /// </summary>
        public string FullName =>
            $"{FamilyName} {FirstName[0]}. {MiddleName?[0]}.".Trim();

        public override string ToString() => this.FullName;
    }
}
