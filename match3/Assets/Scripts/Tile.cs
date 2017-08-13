using UnityEngine;

public class Tile : MonoBehaviour {

	public int xIndex;
	public int yIndex;

	Board m_board;

	public void Init(int x, int y, Board board)
	{
		xIndex = x;
		yIndex = y;
		m_board = board;
	}

	private void OnMouseDown()
	{
		if (m_board != null)
		{
			m_board.ClickTile(this);
		}
	}

	private void OnMouseEnter()
	{
		if (m_board != null)
		{
			m_board.DragToTile(this);
		}
	}

	private void OnMouseUp()
	{
		if (m_board != null)
		{
			m_board.ReleaseTile();
		}
	}
}