namespace OutlookAccessInterface.model.databaseAccessObjects;

public interface IDAO<T>
{
	public void create(T DBObject);
	public void update(T DBObject);
	public void delete(T DBObject);

	public List<T> select_all();
}
