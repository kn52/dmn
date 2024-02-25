package Day44;

public class PalindromeList {

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
		int ans = checkPalindromeList(head);
		System.out.print(ans);
	}

	public static int checkPalindromeList(PalinLinkedList A) {
		PalinLinkedList mid = findMid(A);
		PalinLinkedList head2 = reverse(mid.next);
		PalinLinkedList temp = A, temp2 = head2;

		while (temp != null && temp2 != null) {
			if (temp.val != temp2.val) {
				return 0;
			}
			temp = temp.next;
			temp2 = temp2.next;
		}
		return 1;
	}

	public static PalinLinkedList findMid(PalinLinkedList head) {
		PalinLinkedList slow = head, fast = head;
		while (fast.next != null && fast.next.next != null) {
			slow = slow.next;
			fast = fast.next.next;
		}
		return slow;
	}

	public static PalinLinkedList reverse(PalinLinkedList head) {
		PalinLinkedList nh = null;
		while (head != null) {
			PalinLinkedList temp = head;
			head = head.next;
			temp.next = nh;
			nh = temp;
		}
		return nh;
	}

	public static void printElement(PalinLinkedList head) {
		PalinLinkedList temp = head;
		while (temp != null) {
			System.out.print(temp.val);
			temp = temp.next;
		}
	}
}
