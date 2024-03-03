namespace RFLOT.Domain;

/// <summary>
/// 0 – Ok (Проблем нет),
/// 1 – None (Не найден)
/// 2 – NotFound (Не сканируется),
/// 3 – DataFail (истёк срок годности),
/// 4 – DataMonth (срок годности меньше месяца)
/// </summary>
public enum Status
{
    ///<summary>Проблем нет</summary>
    Ok,

    ///<summary>Не найден</summary>
    None,

    ///<summary>Не сканируется</summary>
    NotFound,

    ///<summary>Истёк срок годности</summary>
    DateFail,

    ///<summary>Срок годности меньше месяца</summary>
    DateMonth
}