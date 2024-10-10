namespace comperhensive_todo_list_api.Services.Objects.General
{
    public class MapObjectToDTO
    {
        public static object Map(object obj, object dto)
        {
            var properties = obj.GetType().GetProperties();
            var dto_props = dto.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                var target = dto_props.Where(prop => prop.Name == property.Name).FirstOrDefault();

                if (target != null)
                {
                    target.SetValue(dto, value);
                }
            }



            return dto;
        }
    }
}
