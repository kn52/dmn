package Day44;

public class ReverseLinkedList {

	public static void main(String[] args) {
		int[] array = new int[] { 1, 2, 2, 1 };
		PalinLinkedList head = new PalinLinkedList(array[0]);
		var temp = head;
		for (int i = 1; i < array.length; i++) {
			PalinLinkedList new_node = new PalinLinkedList(array[i]);
			temp.next = new_node;
			if (i == 1) {
				head.next = temp;
			}
			temp = temp.next;
		}
		PalinLinkedList ans = reverseList(head);
		printElement(ans);
	}
	public static PalinLinkedList reverseList(PalinLinkedList A) {
		PalinLinkedList _new = null;
        while(A != null){
        	PalinLinkedList temp=A;
            A=A.next;
            temp.next=_new;
            _new=temp;
        }
        return _new;
    }
	public static void printElement(PalinLinkedList head) {
		PalinLinkedList temp = head;
		while (temp != null) {
			System.out.print(temp.val);
			temp = temp.next;
		}
	}
}
